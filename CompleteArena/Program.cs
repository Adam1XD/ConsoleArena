using CompleteArena;

Dice dice = new (10);
Warrior warrior1 = new("Adam", 150, 15, 15, "Famous warrior ", dice);
Warrior warrior2 = new Mage("Ghost", 50, 40, 5, "Dangerous mage ", dice, 30, 45);
Arena arena = new(warrior1, warrior2, dice);
arena.Fight();


