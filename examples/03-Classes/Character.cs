public class Character
{
    // Attributes
    public string name;
    public int lifeCharges;
    public float life;
    public float mana;

    // Functions
    public void PrintValues()
    {
        Console.WriteLine("The character life is: " + life);
        Console.WriteLine("The character mana is: " + mana);
        Console.WriteLine("The character life charges is: " + lifeCharges);
    }
}
