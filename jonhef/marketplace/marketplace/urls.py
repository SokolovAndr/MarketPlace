"""marketplace URL Configuration

The `urlpatterns` list routes URLs to views. For more information please see:
    https://docs.djangoproject.com/en/4.1/topics/http/urls/
Examples:
Function views
    1. Add an import:  from my_app import views
    2. Add a URL to urlpatterns:  path('', views.home, name='home')
Class-based views
    1. Add an import:  from other_app.views import Home
    2. Add a URL to urlpatterns:  path('', Home.as_view(), name='home')
Including another URLconf
    1. Import the include() function: from django.urls import include, path
    2. Add a URL to urlpatterns:  path('blog/', include('blog.urls'))
"""
from django.urls import re_path, path
from product import views as viewsp
from userProfile import views as viewsu
from shoppingCart import views as viewss
from mainIndex import views as viewsm
from catalog import views as viewsc
from api import views as viewsa

urlpatterns = [
    #path('admin/', admin.site.urls),
    path('catalog/product/<int:id>', viewsp.product),
    path('catalog/product/<int:id>/', viewsp.product),
    re_path(r'^profile?$', viewsu.profile),
    re_path(r'^profile/shopcart?$', viewss.shopCart),
    re_path(r'^$', viewsm.main),
    re_path(r'^catalog?$', viewsc.catalog),
    re_path(r'^api/product?$', viewsa.requestProduct),
]
