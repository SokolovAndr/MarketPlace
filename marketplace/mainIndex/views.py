from django.shortcuts import render

# Create your views here.
def main(request):
    return render(request, 'index.html')

def req404(request):
    return render(request, '404.html')