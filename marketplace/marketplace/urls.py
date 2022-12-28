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
from django.urls import re_path, path, include
from product import views as viewsProduct
from userProfile import views as viewsUser
from shoppingCart import views as viewsShopCart
from mainIndex import views as viewsMain
from catalog import views as viewsCatalog
from api import views as api

apipatterns = [
    re_path(r'product?$', api.requestProduct),
    re_path(r'catalog?$', api.requestCatalog),
    re_path(r'shopcart?$', api.requestShopCart),
    re_path(r'profile?$', api.requestProfile),
    re_path(r'register?$', api.requestAddProfile),
    re_path(r'login?$', api.requestLogin),
    re_path(r'buy?$', api.requestBuy),
    re_path(r'orders?$', api.requestOrders),
    re_path(r'orderbyid?$', api.requestOrderById),
]

urlpatterns = [
    #path('admin/', admin.site.urls),
    path('catalog/product/<int:id>', viewsProduct.product),
    path('catalog/product/<int:id>/', viewsProduct.product),
    re_path(r'^profile?$', viewsUser.profile),
    re_path(r'^profile/shopcart?$', viewsShopCart.shopCart),
    re_path(r'^$', viewsMain.main),
    re_path(r'^catalog?$', viewsCatalog.catalog),
    path('api/', include(apipatterns)),
    re_path(r'^', viewsMain.req404)
]
