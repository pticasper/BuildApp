using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Data.SqlClient;
using Newtonsoft.Json;

namespace BuildApp.Pages;

public class IndexModel : PageModel
{
     public List<Course> Courses=new List<Course>();
    private readonly ILogger<IndexModel> _logger;
    private IConfiguration _configuration;
    public IndexModel(ILogger<IndexModel> logger,IConfiguration configuration)
    {
        _logger = logger;
        _configuration=configuration;
    }

    public async Task<IActionResult> OnGet()
    {
       
        string functionURL="https://appfunction-e9gcd4dme5cebwfm.francecentral-01.azurewebsites.net/api/appfunction";
        using(HttpClient client=new HttpClient())
        {
            HttpResponseMessage response= await client.GetAsync(functionURL);
            string content= await response.Content.ReadAsStringAsync();
            Courses=JsonConvert.DeserializeObject<List<Course>>(content);
            return Page();
        }       
        
    }
}
