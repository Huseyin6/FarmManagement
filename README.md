# FarmManagement

Bu projede büyükbaş işletmelerinin yönetimi amaçlanmıştır. 
Hayvanların bilgilerinin eklenmesi, güncellenmesi gibi işlemler yapılamaktadır. 
Ayrıca gelir ve giderlerin tiplerine göre kaydedilmesi ve bunların chart'lar ile gösterilmesi yapılmıştır.

## Yapılanlar
* Datatable'larda hayvan bilgileri yönetilebilmektedir. 
* Burada filtreleme ve bazı yönetimsel işlemler yapılamaktadır.
* Buzağılar için 2 aydan büyükler ve sütten ayrılmış olanlar ilgili tabloya aktarılmaktır. 
* Ayrıca 2 aydan büyük buzağılar için sütten ayrılmamış ise kullanıcı bir modal ile bilgilendirilmektedir.
* Finansal işlemlerde ise gelir ve giderler kaydedilmekte, genel durumlar gösterilmektedir.
* Finansal işlemlerdeki istatistik kısımlarında ise bar ve line chartları ile finansal istatistikler ay bazında gösterilmektedir.

## Yapılacaklar
* Home page'e günlük yapılacakların gösterileceği kartlar eklenebilir.
* Home page'e ya da başka bir ekrana bir takvimde yapılacaklar gösterilebilir.
* Hayvan durumu satıldı yapıldığında kaydedilirken satış miktarını gelir tablosuna kaydetmesi için bir modal açılarak kaydedilmeli. Böylece kullanıcı iki işlem yapmadan tek bir yerden yapabilmelidir.

### Kullandığım Yapılar
* AdminBsb Template
* Repository Desing Pattern. İki katman kullandım: Data ve Web(MVC - .net) 
* Unit Of Work
* Heroku Postgre Db
* Entity Framework
* Automapper
* View için bootstrap-switch,jquery datatable, chart.js, datepicker ...
