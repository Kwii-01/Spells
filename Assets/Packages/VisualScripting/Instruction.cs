using System;

using System.Threading;

using Cysharp.Threading.Tasks;

namespace VisualScripting {
    public interface IInstruction<T> {
        public abstract UniTask Execute(T data, CancellationToken token);
    }
}