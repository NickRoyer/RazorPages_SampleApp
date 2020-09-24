using Microsoft.EntityFrameworkCore;

public interface IContextSeeder
{
    void SeedContext(ModelBuilder mb);
}