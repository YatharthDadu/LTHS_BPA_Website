import random
import datetime

'''
HELPER STRINGS -- Feel free to copy these lines to aid in your printouts:


Character save exists. Override (O), Make a new save (N), or Quit (Q)?
Invalid input. Please enter 'O', 'N', or 'Q'.
No save found. Make a new save (N) or Quit (Q)?
Invalid input. Please enter 'N' or 'Q'.
Save Successful!
Would you like to adventure again? (Y/N):
Invalid input. Please enter 'Y' or 'N'.
See you on the next adventure!
'''


'''''''''''''''''''''''''''''
 Write your new function here
'''''''''''''''''''''''''''''



class Character:
    def __init__(self, name, weapon, level=1, strength=random.randint(12, 17), health=random.randint(7, 10) * 10, gold=0, timestamp=''):
        self.name = name
        self.weapon = weapon
        self.level = level
        self.strength = strength
        self.health = health
        self.gold = gold
        self.timestamp = timestamp

def load_characters(filename):
    characters = []
    with open(filename, 'r') as file:
        for line in file:
            name, weapon, level, strength, health, gold, timestamp = line.strip().split(',')
            characters.append(Character(name, weapon, int(level), int(strength), int(health), int(gold), timestamp))
    return characters

def start_menu():
    while True:
        print("BPA Dungeon Adventure")
        print("---------------------")
        print("(N) New Game\n(L) Load Game")
        choice = input("Enter your choice (N/L): ").upper()  # Converts the input to uppercase to handle lowercase inputs
        print()
        if choice == 'L':
            characters = load_characters('GameSaves.txt')
            load_game(characters)
            break  # Break out of the loop if a valid option is chosen
        elif choice == 'N':
            start_new_game()
            break  # Break out of the loop if a valid option is chosen
        else:
            print("Invalid choice!\n")

def start_new_game():
    print("Welcome to the dungeon!\nTreasure awaits for those brave enough to venture inside...")
    name = input("Enter your character's name: ")
    weapon = input("Choose your weapon: ")
    character = Character(name, weapon)
    start_game(character)

def load_game(characters):
    header = "There are " + str(len(characters)) + " available saves:"
    print()
    print(header)
    print("-" * len(header))
    
    for i, char in enumerate(characters):
        line = f"{i+1:>5}. {char.name}\t{'Level ' + str(char.level):>5}\t{char.timestamp:>20}"
        print(line)
    
    while True:  # Loop to allow re-selection if user declines
        try:
            choice = int(input("\nChoose a save to load: ")) - 1
            if 0 <= choice < len(characters):
                selected_char = Character(characters[choice].name, characters[choice].weapon, characters[choice].level, 
                          characters[choice].strength, characters[choice].health, characters[choice].gold, 
                          characters[choice].timestamp)
                display_character(selected_char)  # Show chosen character details
                confirm = input("Load this character? (Y/N): ").upper()
                if confirm == 'Y':
                    # Move on with that character
                    start_game(selected_char)
                    break  # Exit loop if confirmed
                elif confirm == 'N':
                    continue  # Re-display list of saves for a new choice
                else:
                    print("Invalid input. Please enter 'Y' or 'N'.\n")
            else:
                print("Invalid selection.\nPlease choose a number from the list.")
        except ValueError:
            print("Invalid input. Please enter a number.")

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
    # rewrite the for loop to pick up where the character left off
    for i in range(character.level, 4):
        result = encounter(character)
        if character.health <= 0 or result == 2:
            break
        else:
            character.level += 1
        display_character(character)
    game_over(character)

# Main code
characters = load_characters("GameSaves.txt")
start_menu()