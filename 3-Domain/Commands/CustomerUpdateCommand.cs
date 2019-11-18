namespace Domain.Commands
{
    public class CustomerUpdateCommand : CustomerCreateCommand
    {
        public int Id { get; set; }
    }
}