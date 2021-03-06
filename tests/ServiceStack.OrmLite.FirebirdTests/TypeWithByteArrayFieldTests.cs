using NUnit.Framework;

namespace ServiceStack.OrmLite.FirebirdTests
{
    public class TypeWithByteArrayFieldTests : OrmLiteTestBase
    {
        [Test]
        public void CanInsertAndSelectByteArray()
        {
            var orig = new TypeWithByteArrayField { Id = 1, Content = new byte[] { 0, 17, 0, 17, 0, 7 } };

            using (var db = new OrmLiteConnectionFactory(ConnectionString, FirebirdDialect.Provider).Open())
            {
                db.CreateTable<TypeWithByteArrayField>(true);

                db.Save(orig);

                var target = db.GetById<TypeWithByteArrayField>(orig.Id);

                Assert.AreEqual(orig.Id, target.Id);
                Assert.AreEqual(orig.Content, target.Content);
            }
        }
    }

    class TypeWithByteArrayField
    {
        public int Id { get; set; }
        public byte[] Content { get; set; }
    }
}