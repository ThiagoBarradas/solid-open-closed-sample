# SOLID Open-Closed

Based in this article: https://medium.com/thiagobarradas/solid-na-pratica-parte-2-open-closed-977cd027cacd

A simple project to demostrate SOLID Open-Closed Principle.

Request:

```
POST http://localhost:5000/payments
{
    "type" : "CreditCard"
}
```

Response

```
{
    "message": "CreditCardPaymentService.ProcessPayment",
    "type": "CreditCard"
}
```

Changing "type" to "BankInvoice" or "DebitCard" you will can test other payment methods.