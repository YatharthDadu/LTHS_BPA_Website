 
#SC1
import PizzaMenu

class PizzaOrderController:
    
   pizza1 = PizzaMenu.PizzaMenu() #SC2
    
   try: #SC4
      with open("PizzasText.txt") as f:
         pizzaSymbol = f.readline() #SC3
         while (pizzaSymbol.upper().strip()!="STOP"): #SC3
            pizzaName = f.readline() #SC3
            pizzaPrice = f.readline()#SC3
            stockVolume = f.readline()#SC3
         
            pizza1.createPizza(pizzaSymbol, pizzaName, pizzaPrice, stockVolume)
            pizzaSymbol = f.readline()
   except OSError as err: #SC4    
      print("OS error:", err)
      print(exit)  #SC5    
      exit()   
   #GIVEN
   print(pizza1)