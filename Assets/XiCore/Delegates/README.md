# Fast delegates 

Simple wrapper for Action&lt;> and Function&lt;> classes used with my other prjects.
Those classes were designed for speed but not for the memory requirements.

TODO! Consider to use arrays instead of linked list.

## FastAction<>

The function without a result

```C#
FastAction<>
FastAction<A>
FastAction<A, B>
FastAction<A, B, C>
```
 
## FastFunc<> 

The function with result. This way is possible to call this delegate until it will get some expected or unexpected result.

```C#
FastFunc<TResult>
FastFunc<A, TResult>
FastFunc<A, B, TResult>
FastFunc<A, B, C, TResult>
```