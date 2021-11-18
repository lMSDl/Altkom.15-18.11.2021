namespace WPC.Behavioral.Mediator
{
    public interface IChatMediator
    {
        void Join(ChatMember member);
        void Quit(ChatMember chat);
        void Send(string from, string to, string message);
        void Send(string from, string message);
    }

}
