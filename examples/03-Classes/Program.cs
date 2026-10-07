Character player = new Character();
player.name = "Player";
player.life = 100;
player.mana = 1000;
player.lifeCharges = 3;
player.PrintValues();

Console.WriteLine("");

Character enemy = new Character();
enemy.name = "Player";
enemy.life = 30;
enemy.mana = 500;
enemy.lifeCharges = 1;
enemy.PrintValues();

// Pokemon example

public class Attack
{
    public string name;
    public float damage;

    public Attack(string name, float damage)
    {
        this.name = name;
        this.damage = damage;
    }
}

public class Pokemon
{
    public string name;
    public float life;
    public Attack[] attacks;

    public Pokemon(string name, float life)
    {
        this.name = name;
        this.life = life;
    }
}

bool gameFinished = false;


Pokemon pickachu = new Pokemon("Pikachu", 100)
Pokemon charizard = new Pokemon("Charizard", 300)

Attack fastAttack = new Attack("Fast Attack", 10)
Attack volt = new Attack("Volt", 20)
Attack flames = new Pokemon("Flames", 40)

pickachu.attacks[0] = fastAttack;
pickachu.attacks[1] = volt;

charizard.attacks[0] = fastAttack;
charizard.attacks[1] = flames;

Pokemon pokemonA = pickachu;
Pokemon pokemonB = charizard;

while(!gameFinished)
{
   Console.WriteLine("Choose an attack:") 
   int attackIndex = Convert.ToInt32(Console.ReadLine());
   Attack selectedAttack = pokemonA.attacks[attackIndex]
   Console.WriteLine("Attack choosed is: " + selectedAttack.name);
   pokemonB.life -= selectedAttack.damage;
   Console.WriteLine(pokemonB.name + " was hitted by " + pokemonA.name);
   Console.WriteLine(pokemonB.name + " life now is " + pokemonB.life);
   if (pokemonB.life <= 0)
   {
        Console.WriteLine(pokemonA.name + " wins.");
        gameFinished = true;
        break;
   }
   // Swap the pokemons.
   Pokemon prevPokemonB = pokemonB;
   pokemonB = pokemonA;
   pokemonA = prevPokemonB;
}
