using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace McTours.Domain
{
    public class Passenger
    {

        public Passenger()
        {
            Tickets=new List<Ticket>(); 
        }

        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string IdentityNumber { get; set; }
        public Gender Gender { get; set; }
        public DateTime DateOfBirth { get; set; }

        //IEnumarable ile foreach ile gezinebilirim length ine göre ama ekleme çıkartma yapamam
        //ICollection da ise foreach ile count una göre gezinebilir aynı zamanda ekleme çıkartma yapabilirim
        //IList ise index olarak for ile dolaşmamızı sağlar fakat ben bunu service de linq ile vs zaten dolaşabiliyorum.
        //Oyüzden iyi düşünmek gerek o yüzden ICollection ihtiyacımızı giderir burada önemli olan readonly yapmak const içerisinde instance almak
        //Çünkü ben navigationa eget seti açık bırakırsam dış dünyadan null set edilebilir.

        // Bir sınıfta koleksiyon varsa biz mutlaka get'ini sadece açık bırakalım. CONSTRUCTOR OLARAK İNSTANCE ALALIM. 
        public ICollection<Ticket> Tickets { get; }

       /*
        ICollection<Ticket> Ticketets { get; } -> Koleksiyonların ekleme, çıkarma, silme işlemleri yapılabilir. Burada index mantığı yoktur. Dış dünyaya  
         ekleme çıkarma yapması için constructor metodu oluşturulur. orada da list belirli limitli şeyler kullanılırken hashSet ile daha performanslı olacak şekilde dizayn edilebilir.Ancak index 
         mantığı yoktur hashSet 'te. 
        IEnumerable<Ticket> Tics { get; } -> Burada forech mantığı çalışır ekleme çıkarma ve silme işlemi yapılmayacaksa IEnumarable yapılabilir. 
        IList<Ticket> Tics2 { get; }  -> index mantığı ile çalışır. Belirli limitteki listeler için kullanılmaktadır. 
        HashSet -> Burada index mantığı olmadığı için sırasız şekilde hash değeri verilerek değer saklanır. ve performansı yüksektir. 
       */

        //Concrete => Katı, somut
        //List, Collection, HashSet

        //Abstract => Soyut
        //IEnumarable, ICollection, IList

        //Interface bir soyutlama (abstraction) yapısıdır.
        //Interface ile bir tipte bulunması gereken davranışlar bildirilir.
        //Interface üzerinde hangi üyeler tanımlanbailir? => Property, method
        //Ancak o davaranışın nasıl yerine getirildiğini bildirmez. 
        //Diğer bir ifadeyle; interface bir davranışı (property, method) implement edilmez. 

        //Bu özelliğinden dolayı ınterface'lere SÖZLEŞME (Kontrat) da denir.

        //Interface ne olması gerektiğini söyler nasıl olması gerektiğini söylemez. 
    }
}
