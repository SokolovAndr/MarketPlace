from django.urls import path, re_path
from . import views

urlpatterns = [
    path('', views.index),
    path('catalog', views.catalog),
    path('product', views.product),
    path('cart', views.cart),
]
