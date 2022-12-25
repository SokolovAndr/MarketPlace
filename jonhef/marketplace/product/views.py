from django.shortcuts import render
import json

# Create your views here.
def product(request, id):
    #file = open("C:\Проекты\GithubMarketPlace\MarketPlace\jonhef\marketplace\\resources.json", "r")
    #with open('C:\Проекты\GithubMarketPlace\MarketPlace\jonhef\marketplace\\resources.json') as f:
    #    s = f.read()
    #s.replace('\n', " ")
    #index = json.load(s)["productlink"]
    data = {"id" : id}
    index = 'jonhef.github.io'
    return render(request, 'product.html', context=data)