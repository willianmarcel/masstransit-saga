namespace OrderApi.Dtos;

public class CreateOrderDto
{
    public CreateOrderDto()
    {
    }
    public int CustomerId { get; set; }
    public DateTime OrderDate { get; set; }
}
