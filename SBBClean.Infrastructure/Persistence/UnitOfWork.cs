using SBBClean.Application.Interfaces;

namespace SBBClean.Infrastructure.Persistence;

public class UnitOfWork(AppDbContext context):IUnitOfWorks
{
    public async Task<int> SaveChangesAsync()
    {
        return await context.SaveChangesAsync();

    }
}