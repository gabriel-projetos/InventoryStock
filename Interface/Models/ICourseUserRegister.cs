using Interfaces.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interface.Models
{
    public interface ICourseUserRegister : IBaseModel
    {
        /// <summary>
        /// Uid do usuário registrado.
        /// </summary>
        Guid UserUid { get; set; }
        
        Guid DbRegisterUid { get; set; }

        /// <summary>
        /// Status do registro do usuário no curso.
        /// Apenas com o status Active, o acesso ao conteúdo é liberado
        /// </summary>
        ContentStatus AccessStatus { get; set; }

        /// <summary>
        /// Andamento atual do curso para ó usuário.
        /// </summary>
        UserRegisterStatus RegisterStatus { get; set; }

        /// <summary>
        /// Data que o usuário finalizou todas as atividades do curso pela primeira vez.
        /// </summary>
        DateTime? CompletedAt { get; set; }
    }
    public enum UserRegisterStatus
    {
        NotAttempted,
        Started,
        Completed,
        Passed,
        Failed,
        Abandoned
    }
    public enum ContentStatus
    {
        Undefined,
        PendingPayment,
        PaymentFailed,
        Active,
        Blocked,
        Inactive
    }
}
