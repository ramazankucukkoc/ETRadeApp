using ETRadeApp.Core.Bases;

namespace ETRadeApp.Core.RabbitMq
{
    public class Message:BaseEntity<int>
    {   
            public string? Content { get; set; }    
    }
}
