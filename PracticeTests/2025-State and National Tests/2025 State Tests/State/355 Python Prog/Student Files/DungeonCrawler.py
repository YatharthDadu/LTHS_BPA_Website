import random

def display_character(char):
    print(f"\nName: {char.name}\t\tLevel: {char.level}")
    print(f"Gold: {char.gold:02d}\t\tWeapon: {char.weapon}")
    print(f"Health: {char.health}\t\tStrength: {char.strength}\n\n")

def found_loot(char):
    loot = random.choice('ggggggghhh')
    if loot == 'g':
        new_gold = random.randint(25, 150)
        char.gold += new_gold
        return f"{new_gold} gold"
    else:
        bonus = random.randint(1, 3) * 10
        char.health += bonus
        return f"a health potion. You restored {bonus} health"

def encounter(char):
    print("A monster is attacking you!")
    while True:
        try:
            attack = int(input(f"Enter:\t'1' to use your {char.weapon},\n\t'2' to run away\nChoice: "))
            if attack < 1 or attack > 2:
                print("Invalid choice!")
            else:
                break
        except ValueError:
            print("Invalid Choice!")
    if attack == 1:
        monster = random.randint(10, 20)
        result = char.strength - monster
        if result >= 0:
            reward = found_loot(char)
            input(f"\nYou defeated the monster and found {reward}!\nPress Enter to continue")
        else:
            char.health -= abs(result) * 10
            print(f"\nThat was rough! You lost {abs(result) * 10} health.")
            if char.health <= 0:
                char.health = 0
            else:
                input("Luckily you managed to get past the monster!\nPress Enter to continue")
    return attack

def game_over(char):
    if char.health > 0 and char.level == 4:
        treasure = random.randint(500, 5000)
        char.gold += treasure
        print(f"\nYou made it to the treasure! You found {treasure} gold!")
    elif char.health > 0 and char.level < 4:
        print("\nYou didn't find the treasure, but you survived to fight again another day...")
    else:
        print("\nYou fought as best you could, but didn't make it.\nThe treasure waits for the next adventurer...")
    display_character(char)

def start_game(character):
    display_character(character)
    
    # Rewrite this for loop to pick up where the saved character left off
    for i in range(3):
        result = encounter(character)
        if character.health <= 0 or result == 2:
            break
        else:
            character.level += 1
        display_character(character)
        
    game_over(character)