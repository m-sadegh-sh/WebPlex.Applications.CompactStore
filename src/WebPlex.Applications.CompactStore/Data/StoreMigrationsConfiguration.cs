namespace WebPlex.Applications.CompactStore.Data {
    using System;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using WebPlex.Applications.CompactStore.Data.Repositories;
    using WebPlex.Applications.CompactStore.Helpers;
    using WebPlex.Applications.CompactStore.Models;
    using WebPlex.Applications.CompactStore.Security;

    public sealed class StoreMigrationsConfiguration : DbMigrationsConfiguration<StoreContext> {
        public StoreMigrationsConfiguration() {
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(StoreContext context) {
            CreateCustomers(context);
            CreateCategories(context);
            CreateProducts(context);
        }

        private static void CreateCustomers(StoreContext context) {
            var customerRepository = new CustomerRepository(context);

            if (!customerRepository.IsEmpty())
                return;

            var securedSalt = SecurityHelpers.GenerateSalt();
            var securedPassword = SecurityHelpers.HashPassword("qw12QW!@", securedSalt);

            customerRepository.AddOrUpdate(new CustomerModel {
                CellPhone = "09360643405",
                SecuredSalt = securedSalt,
                SecuredPassword = securedPassword,
                FirstName = "محمد صادق ",
                LastName = "شاد",
                Email = "sadegh@webplex.ir",
                LockedOutDateUtc = new DateTime(1990, 1, 1)
            });

            customerRepository.SaveChanges();
        }

        private static void CreateCategories(StoreContext context) {
            var categoryRepository = new CategoryRepository(context);

            if (!categoryRepository.IsEmpty())
                return;

            categoryRepository.AddOrUpdate(new CategoryModel {
                DisplayOrder = 1,
                Title = "مدیریت دسترسی",
                Slug = StringHelpers.Slugify("AccessManagement"),
                MetaKeywords = "دسترسی دهی، Permission",
                MetaDescription = "توضیحات متا",
                CssClass = "AccessManagement"
            });

            categoryRepository.AddOrUpdate(new CategoryModel {
                DisplayOrder = 2,
                Title = "تقویم",
                Slug = StringHelpers.Slugify("Calendar"),
                MetaKeywords = "تقویم, Calendar",
                MetaDescription = "توضیحات متا",
                CssClass = "Calendar"
            });

            categoryRepository.AddOrUpdate(new CategoryModel {
                DisplayOrder = 3,
                Title = "برنامه نویس",
                Slug = StringHelpers.Slugify("Developer"),
                MetaKeywords = "برنامه نویس, توسعه، تولید, Develop, Development, Programming, Deploy, Retract, XSLT, SPWebApplication, SPSite, SPWeb, SPList, SPListItem",
                MetaDescription = "توضیحات متا",
                CssClass = "Developer"
            });

            categoryRepository.AddOrUpdate(new CategoryModel {
                DisplayOrder = 4,
                Title = "مناقصات و مزایدات",
                Slug = StringHelpers.Slugify("Tenders"),
                MetaKeywords = "مناقصات و مزایدات, Tender, Tenders",
                MetaDescription = "توضیحات متا",
                CssClass = "Tenders"
            });

            categoryRepository.AddOrUpdate(new CategoryModel {
                DisplayOrder = 5,
                Title = "کاربر",
                Slug = StringHelpers.Slugify("User"),
                MetaKeywords = "کاربر, User",
                MetaDescription = "توضیحات متا",
                CssClass = "User"
            });

            categoryRepository.AddOrUpdate(new CategoryModel {
                DisplayOrder = 6,
                Title = "اس‌اس‌او",
                Slug = StringHelpers.Slugify("SingleSignOn"),
                MetaKeywords = "لاگین، فقط یک بار، ورود، SSO، Single Sign On",
                MetaDescription = "توضیحات متا",
                CssClass = "SingleSignOn"
            });

            categoryRepository.AddOrUpdate(new CategoryModel {
                DisplayOrder = 7,
                Title = "خرید",
                Slug = StringHelpers.Slugify("Shopping"),
                MetaKeywords = "خرید, Purchase, فروشگاه, Shopping",
                MetaDescription = "توضیحات متا",
                CssClass = "Shopping"
            });

            categoryRepository.AddOrUpdate(new CategoryModel {
                DisplayOrder = 8,
                Title = "نظرسنجی",
                Slug = StringHelpers.Slugify("Polling"),
                MetaKeywords = "نظرسنجی, Poll, Vote, Survey",
                MetaDescription = "توضیحات متا",
                CssClass = "Polling"
            });

            categoryRepository.AddOrUpdate(new CategoryModel {
                DisplayOrder = 9,
                Title = "پروفایل",
                Slug = StringHelpers.Slugify("Profile"),
                MetaKeywords = "پروفایل, Profile, Social",
                MetaDescription = "توضیحات متا",
                CssClass = "Profile"
            });

            categoryRepository.AddOrUpdate(new CategoryModel {
                DisplayOrder = 10,
                Title = "آفیس",
                Slug = StringHelpers.Slugify("Office"),
                MetaKeywords = "آفیس, Office, آفیس 2010, Office 2010, آفیس 2013, Office 2013, آفیس 365, Office 365, ورد, Word, اکسل, Excel, آوتلوک, اوتلوک, Outlook",
                MetaDescription = "توضیحات متا",
                CssClass = "Office"
            });

            categoryRepository.AddOrUpdate(new CategoryModel {
                DisplayOrder = 11,
                Title = "رابط کاربری",
                Slug = StringHelpers.Slugify("UserInterface"),
                MetaKeywords = "رابط کاربری, UI, UX, XSL, XSLT, CSS",
                MetaDescription = "توضیحات متا",
                CssClass = "UserInterface"
            });

            categoryRepository.AddOrUpdate(new CategoryModel {
                DisplayOrder = 12,
                Title = "اطلاع رسانی",
                Slug = StringHelpers.Slugify("Notification"),
                MetaKeywords = "اطلاع رسانی, Notification, Alert",
                MetaDescription = "توضیحات متا",
                CssClass = "Notification"
            });

            categoryRepository.AddOrUpdate(new CategoryModel {
                DisplayOrder = 13,
                Title = "خبر",
                Slug = StringHelpers.Slugify("NewsManagement"),
                MetaKeywords = "خبر, News, News Management",
                MetaDescription = "توضیحات متا",
                CssClass = "NewsManagement"
            });

            categoryRepository.AddOrUpdate(new CategoryModel {
                DisplayOrder = 14,
                Title = "زیرساخت",
                Slug = StringHelpers.Slugify("Infrastructure"),
                MetaKeywords = "زیرساخت, Infrastructure",
                MetaDescription = "توضیحات متا",
                CssClass = "Infrastructure"
            });

            categoryRepository.AddOrUpdate(new CategoryModel {
                DisplayOrder = 15,
                Title = "اطلاعات روز",
                Slug = StringHelpers.Slugify("DailyEvents"),
                MetaKeywords = "اطلاعات روز",
                MetaDescription = "توضیحات متا",
                CssClass = "DailyEvents"
            });

            categoryRepository.AddOrUpdate(new CategoryModel {
                DisplayOrder = 16,
                Title = "سی‌ام‌اس",
                Slug = StringHelpers.Slugify("ContentManagement"),
                MetaKeywords = "مدیریت محتوا, سیستم مدیریت محتوا, CMS, Content, Content Management",
                MetaDescription = "توضیحات متا",
                CssClass = "ContentManagement"
            });

            categoryRepository.SaveChanges();
        }

        private static void CreateProducts(StoreContext context) {
            var categoryRepository = new CategoryRepository(context);
            var categoryIds = categoryRepository.GetAll().ToArray();

            var productRepository = new ProductRepository(context);

            if (!productRepository.IsEmpty())
                return;

            for (var i = 1; i <= 100; i++) {
                productRepository.AddOrUpdate(new ProductModel {
                    Id = i,
                    Category = RandomHelpers.GetRandom(categoryIds),
                    Title = string.Format("محصول آزمایشی {0}", i),
                    Slug = StringHelpers.Slugify(string.Format("Test Product {0}", i)),
                    Summary = "خلاصه ای در مورد این محصول",
                    Description = "توضیحات کامل مربوط به این محصول.",
                    Features = "<ul><li>ویژگی شماره 1</li><li>ویژگی شماره 2</li><li>ویژگی شماره 3</li><li>و...</li></ul>",
                    MetaKeywords = "کلمه 1, کلمه 2, کلمه 3",
                    MetaDescription = "توضیحاتی در مورد محصول",
                    UnitPrice = 55500*i,
                    ReleaseDateUtc = RandomHelpers.GetRandom(DateTime.UtcNow.AddYears(-2), DateTime.UtcNow),
                    LastModifiedDateUtc = RandomHelpers.GetRandom(DateTime.UtcNow.AddYears(-1), DateTime.UtcNow),
                    ViewsCount = 0,
                    AddedToCartCount = 0
                });
            }

            productRepository.SaveChanges();
        }
    }
}
