import Pizzas
 
class PizzaMenu:
  def __init__(self):  #SC6
    self.pizza = []
    self.size = 0
 
  def createPizza(self, sym, nam, pri, sha):  #SC7
    temp = Pizzas.Pizzas(sym, nam, pri, sha)
    self.pizza.append(temp)
    self.size += 1
 
  def getInventoryTVL(self):  #SC8
    tempValue = 0
    for s in self.pizza:
      tempValue += float(s.getValue())

    return tempValue
 
  def __str__(self):  #SC9
    portfolioPrinter = ""
    tempCount = 0
    while(tempCount < self.size):
      portfolioPrinter = portfolioPrinter + str(self.pizza[tempCount].printPizzaType()) + "\n"  #SC10
      tempCount += 1

    self.stringValue = str(self.getInventoryTVL()) 
    return f"Current Active Inventory:\n\n{portfolioPrinter} \nInventory Total Value: $  {self.stringValue}"  #SC11