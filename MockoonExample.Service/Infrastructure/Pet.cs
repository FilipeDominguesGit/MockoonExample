namespace MockoonExample.Service.Infrastructure
{
    public record Pet(int Id, Category Category, string Name, List<string> PhotoUrls, List<Tag> Tags, string status);
}
