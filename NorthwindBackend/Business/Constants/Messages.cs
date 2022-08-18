using Core.Entities.Concrete;
using System.Runtime.Serialization;

namespace Business.Constants
{
    public static class Messages
    {
        public const string TechnicalErrorFirstPart = "Teknik hata: ";
        public const string ProductAdded = "Ürün eklendi";
        public const string ProductNameInvalid = "Ürün ismi geçersiz";
        public const string MaintanenceTime = "Bakım saatindeyiz";
        public const string ListedProducts = "Ürünler listelendi";
        public const string ProductCountOfCategoryError = "Kategorideki ürün sayısını aşamazsınız";
        public const string ProductNameAlreadyExists = "Bu isimle zaten bir ürün bulunmakta";
        public const string CategoryDoesNotExists = "Bu id'ye sahip bir kategori bulunmamakta";
        public const string ListedCategories = "Kategoriler listelendi";
        public const string AuthorizationDenied = "Yetkiniz yok";
        public const string UserRegistered = "Kayıt oldu";
        public const string PasswordError = "Şifre hatalı";
        public const string UserNotFound = "Kullanıcı bulunamadı";
        public const string AccessTokenCreated = "AccessToken oluşturuldu";
        public const string SuccessfulLogin = "Başarılı giriş";
        public const string UserAlreadyExists = "Kullanıcı mevcut";
    }
}