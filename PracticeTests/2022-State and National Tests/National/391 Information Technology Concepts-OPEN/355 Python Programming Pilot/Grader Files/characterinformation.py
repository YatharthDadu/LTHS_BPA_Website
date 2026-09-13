# Character Information Program
# MemberID

import character

def main():
    # Local variables
    hero_name= ''
    hero_id = ''
    hero_shift = 0
    hero_pay = 0.0

    boss_name= ''
    boss_id = ''
    boss_level = 0
    boss_hp = 0.0
    boss_attack_damage = 0.0
    boss_lifespan = 0.0

    # Get Hero data attributes
    print ('Hero Data Entry:')
    hero_name = input('Enter the hero name: ')
    hero_id = input('Enter the character ID number: ')
    hero_level = int(input('Enter the hero level: '))
    hero_loot = float(input('Enter the hero loot value: '))

    # Create an instance of Hero
    hero = character.Hero(hero_name, hero_id, hero_level, hero_loot)


    # Get Boss data attributes.
    print ('')
    print ('Boss Data Entry:')
    boss_name = input('Enter the boss name: ')
    boss_id = input('Enter the character ID number: ')
    boss_level = int(input('Enter the boss level: '))
    boss_hp = float(input('Enter the boss hp: '))
    boss_attack_damage = float(input('Enter the boss attack damage: '))

    # Create an instance of Boss.
    boss = character.Boss(boss_name, boss_id, boss_level, boss_hp, boss_attack_damage)


    # Display Hero information
    print ('')
    print ('Hero information:')
    print (f'Name: {hero.get_name()}')
    print (f'ID number: {hero.get_id_number()}')
    print (f'Level: {hero.get_level()}')
    print (f'Loot: ${hero.get_loot():,.2f}')

    # Display Boss information.
    print ('')
    print ('Boss information: ')
    print (f'Name: {boss.get_name()}')
    print (f'ID number: {boss.get_id_number()}')
    print (f'Level: {boss.get_level()}')
    print (f'HP: {boss.get_hp()}')
    print (f'Attack Damage: {boss.get_attack_damage()}')
    print (f'Lifespan: {boss.get_lifespan():,.2f} attacks')

# Call the main function.
if __name__ == '__main__':
    main()
