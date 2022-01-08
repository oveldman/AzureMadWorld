namespace MadWorld.Guardian;
public class Guard : IGuardClause
{
    public static IGuardClause Against = new Guard();

    private Guard() { }
}

