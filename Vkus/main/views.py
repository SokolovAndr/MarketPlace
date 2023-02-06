from django.shortcuts import render
from django.http import HttpResponse


def index(request):
    return render(request,'main/index.html')

def cart(request):
    return render(request,'main/cart.html')

def catalog(request):
    return render(request,'main/catalog.html')

def product(request):
    return render(request,'main/product.html')