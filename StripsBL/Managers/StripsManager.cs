using StripsBL.Exceptions;
using StripsBL.Interfaces;
using StripsBL.Model;

namespace StripsBL.Managers;

public class StripsManager
{
    private IStripsRepository stripsRepository;

    public StripsManager(IStripsRepository stripsRepository)
    {
        this.stripsRepository = stripsRepository;
    }

    public Strip GeefStrip(int id)
    {
        try
        {
            Strip strip = stripsRepository.GeefStrip(id);

            return strip;
        }
        catch (Exception ex)
        {
            throw new StripsManagerException("GeefStrip", ex);
        }
    }
}