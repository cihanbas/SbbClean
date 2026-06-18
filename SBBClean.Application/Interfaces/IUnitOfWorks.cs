namespace SBBClean.Application.Interfaces;

public interface IUnitOfWorks
{
    Task<int>  SaveChangesAsync();
}