import random
import DungeonCrawler

'''
HELPER STRINGS -- Feel free to copy these lines to aid in your printouts:


Enter your choice (N/L):
Invalid choice!
Choose a save to load:
Load this character? (Y/N):
Invalid input. Please enter 'Y' or 'N'.
Invalid selection.\nPlease choose a number from the list.
Invalid input. Please enter a number.
'''


# create Character class here


# create functions here

def start_menu():
    print("BPA Dungeon Adventure")
    print("---------------------")
    print("(N) New Game\n(L) Load Game")
    

def start_new_game():
    print("Welcome to the dungeon!\nTreasure awaits for those brave enough to venture inside...")
    name = input("Enter your character's name: ")
    weapon = input("Choose your weapon: ")

# main code
start_menu()