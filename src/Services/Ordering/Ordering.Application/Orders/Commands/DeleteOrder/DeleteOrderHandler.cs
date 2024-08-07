namespace Ordering.Application.Orders.Commands.DeleteOrder;

public class DeleteOrderHandler(IApplicationDbContext dbcontext) : ICommandHandler<DeleteOrderCommand, DeleteOrderResult>
{
    public async Task<DeleteOrderResult> Handle(DeleteOrderCommand command, CancellationToken cancellationToken)
    {
        var orderId = OrderId.Of(command.OrderId);

        var order = await dbcontext.Orders
            .FindAsync([orderId], cancellationToken: cancellationToken) ?? throw new OrderNotFoundException(command.OrderId);

        dbcontext.Orders.Remove(order);
        await dbcontext.SaveChangesAsync(cancellationToken);

        return new DeleteOrderResult(true);
    }
}
