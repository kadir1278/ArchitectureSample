using CoreLayer.Business.Abstract;

namespace DataAccessLayer.Absctract
{
    public interface IWorker : IDisposable
    {
        IUserDal UserDal { get; }
        ITCMBExchangeService TcmbExchangeService { get; }
        INetherlandRdwService NetherlandRdwService { get; }

        /// <summary>
        /// Bir transcation session başlatılır 
        /// </summary>
        public void StartTransaction();
        /// <summary>
        /// Yapılan db işlemleri transaction içerisinde kayıt edilir
        /// Transaction için engel teşkil eden bir durum var mı kontrol edilir
        /// </summary>
        public void SaveChanges();
        /// <summary>
        /// Yapılan db işlemleri transaction içerisinde kayıt edilir
        /// Transaction commitlenir ve kapatılır
        /// </summary>
        public void CommitAndSaveChanges();
        /// <summary>
        /// Transaction içerisinde yapılan tüm veritabanı işlemleri geri çekilir ve transaction iptal edilir
        /// </summary>
        public void RollbackTransaction();
        /// <summary>
        /// Transaction bellekten kaldırılır
        /// </summary>
        public void DisposeTransaction();
    }
}
