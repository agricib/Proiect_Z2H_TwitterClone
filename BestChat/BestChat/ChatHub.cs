using DataModels;
using Microsoft.AspNet.SignalR;
using System;
using System.Threading.Tasks;
using System.Linq;
using User.Entities;

namespace BestChat
{
    [Authorize]
    public class ChatHub : Hub
    {
        //functie care specifica ce face serverul in momentul cand se trimite un mesaj
        public void Send(string names, string message)
        {
            //Usernamul userului curent;
            string name = Context.User.Identity.Name;

            //functie de afisare a mesajului(este definita in index)
            Clients.Group(names).addNewMessageToPage(name,message);

            //pune mesajul in baza de date
            using (var context = new UserContext())
            {
                context.MessageSet.Add(new Message()
                {
                    Sender=name.ToString(),
                    Receiver=names.ToString(),
                    TextMessage=message,
                    Time = DateTime.Now
                });
                //salveaza modificarile din baza de date
                context.SaveChanges();
            }
        }

        //Atunci cand conexiunea este creeata se adauga userul in grupul special destinat lui
        public override Task OnConnected()
        {
            string name = Context.User.Identity.Name;

            Groups.Add(Context.ConnectionId, name);

            return base.OnConnected();
        }
        //Cand conexiunea este pe disconnect grupul destinat userului proaspat iesit se sterge actualizeaza si baza de date
        public override Task OnDisconnected(bool stopCalled)
        {
            //numele utilizatorul curent
            var name = Context.User.Identity.Name;

            //seteaza utlizatorul ca offline in baza de date
            using (var context = new UserContext())
            {
                var user  = context.UserSet
                     .SingleOrDefault(b => b.UserName == name);
                user.Online = false;
                context.SaveChanges(); 
            }
            
            
            Groups.Remove(Context.ConnectionId, name);
            
            return base.OnDisconnected(stopCalled);
        }
        //at cand se reconecteaza utlizatorul este setat din nou pe online
        public override Task OnReconnected()
        {
            var name = Context.User.Identity.Name;
            using (var context = new UserContext())
            {
                var user = context.UserSet
                     .SingleOrDefault(b => b.UserName == name);
                user.Online = true;
                context.SaveChanges();

            }
            //adauga numele utilizatorului din nou
            Groups.Add(Context.ConnectionId, name);

            return base.OnReconnected();
           
        }

    }
}