using JsonProject.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;

namespace JsonProject.Pages;

public class IndexModel : PageModel
{
    private readonly ILogger<IndexModel> _logger;

    public List<Post> Posts { get; set; }

    public IndexModel(ILogger<IndexModel> logger)
    {
        _logger = logger;
    }

    public async Task OnGet()
    {
        using (HttpClient client = new HttpClient())
        {
            string url = "https://jsonplaceholder.typicode.com/posts";
            var response = await client.GetStringAsync(url);
            Posts = JsonConvert.DeserializeObject<List<Post>>(response);
        }
    }
}
