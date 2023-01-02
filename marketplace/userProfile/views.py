from django.shortcuts import render

# Create your views here.
def profile(request):
    return render(request, 'profile.html')

def login(request):
    url = request.GET.get('url')
    return render(request, 'reglog/index.html', context={'url':url})