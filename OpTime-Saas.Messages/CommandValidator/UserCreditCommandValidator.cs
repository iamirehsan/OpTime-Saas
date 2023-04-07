using FluentValidation;
using OpTime_Saas.Messages.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpTime_Saas.Messages.CommandValidator
{
    public class UserCreditCommandValidator : AbstractValidator<UserCreditCommand>
    {
        public UserCreditCommandValidator()
        {
            RuleFor(x => x.UserName).NotEmpty().WithMessage("نام کاربری نمیتواند خالی باشد.");
            RuleFor(x => x.FirstName).NotEmpty().WithMessage("نام کاربر نمیتواند خالی باشد");
            RuleFor(x => x.LastName).NotEmpty().WithMessage("نام خانوادگی کارربر نمیتواند خالی باشد");
            RuleFor(x => x.Password).NotEmpty().WithMessage("رمز عبور کارربر نمیتواند خالی باشد");
            RuleFor(x => x.Credit).Equal(1000000).When(x=>x.Credit==0);

            RuleFor(x => x.Credit).GreaterThanOrEqualTo(0).WithMessage("اعتبار نمیتواند منفی باشد");
            RuleFor(x => x.ExpirationDate).NotEmpty().WithMessage("تاریخ اتمام اعتبار نمیتواند خالی باشد");
            RuleFor(x => x.ExpirationDate).GreaterThanOrEqualTo(DateTime.Now).WithMessage("تاریخ اتمام اعتبار نمیتواند کمتر از تاریخ حال حاضر باشد. ");
        }
    }
}
