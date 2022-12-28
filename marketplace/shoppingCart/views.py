from django.shortcuts import render

# Create your views here.
def shopCart(request):
    return render(request, 'shoppingcart.html')