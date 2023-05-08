using Ecommerceproject.Models;
using Ecommerceproject.Services.Repositories;

namespace Ecommerceproject.Services.DatabaseServices;

public class ColourDbServices
{
    #region
    private readonly ColourDbRepo _colourService;

    public ColourDbServices(ColourDbRepo colourService)
    {
        _colourService = colourService;
    }
    #endregion

    //Gets all available colours
    public async Task<List<CheckBoxModel>> GetAllColours()
    {
        var result = await _colourService.GetAllAsync();
        if (result != null) 
        {
            List<CheckBoxModel> colours = new List<CheckBoxModel>();
            foreach (var colour in result)
            {
                colours.Add(new CheckBoxModel
                {
                    Name = colour.Colour
                });
            }
            return colours;
        }
        return null!;
    }
}
