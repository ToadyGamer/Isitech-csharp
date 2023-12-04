using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using TP.Models;

namespace TP.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {
        return View();
    }

    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }

    private void oui(object sender, EventArgs e)
    {     
        MySqlConnection connexion;
        try
        {
            string connect = "SERVER=" + IP.Text + ";DATABASE=" + nomdebase.Text + ";UID=" + nomuser.Text + ";PASSWORD=" + mdp.Text;
            connexion = new MySqlConnection(connect);
            connexion.Open();
            if (connexion.State.ToString() != "Open")
            {
                MessageBox.Show("Etat de la connexion : " + connexion.State);
            }
            else
            {
                MessageBox.Show("Connexion : " + connexion.State);
            }
        }
        catch (Exception ex)
        {
            MessageBox.Show("Erreur de connexion : " + ex.Message);
        }
    }
}
