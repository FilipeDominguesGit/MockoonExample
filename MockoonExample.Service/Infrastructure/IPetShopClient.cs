namespace MockoonExample.Service.Infrastructure
{
    public interface IPetShopClient
    {
        Task<Pet?> CreatePetAsync(Pet pet);
        Task<Pet?> GetPetByIdAsync(int id);
    }
}