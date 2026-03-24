![ES-1](https://github.com/user-attachments/assets/50ceb623-b073-4344-ad6e-7435d714623a)

## 🥁 CarnaCode 2026 - Challenge 06 - Adapter

Hi, I'm Felipe Parizzi Galli, and this is the space where I share my learning journey during the **CarnaCode 2026** challenge, hosted by [balta.io](https://balta.io). 👻

Here you'll find projects, exercises, and code that I'm building throughout the challenge. The goal is to get hands-on, test ideas, and track my progress in the world of technology.

### About this challenge

In the **Adapter** challenge, I had to solve a real-world problem by implementing the corresponding **Design Pattern**.
During this process, I learned:

- ✅ Software Best Practices
- ✅ Clean Code
- ✅ SOLID
- ✅ Design Patterns

## Problem

A modern e-commerce platform needs to integrate with a legacy payment processing system that uses interfaces and data structures incompatible with the current system.
The current code cannot use the legacy system without major changes to the application.

## About CarnaCode 2026

The **CarnaCode 2026** challenge consists of implementing all 23 Design Patterns in real-world scenarios. Across the 23 challenges in this journey, participants are trained to identify non-scalable code and solve problems using industry-standard patterns.

### eBook - Design Patterns Fundamentals

My main source of knowledge during the challenge was the free eBook [Design Patterns Fundamentals](https://lp.balta.io/ebook-fundamentos-design-patterns).

## What was done to apply the Adapter pattern

- Created a standard contract for the checkout flow using `IPaymentProcessor`, with `ProcessPayment`, `RefundPayment`, and `CheckStatus`.
- Kept `CheckoutService` dependent only on this interface, so the checkout logic remains unchanged regardless of payment provider.
- Implemented `PaymentAdapter` to wrap `LegacyPaymentSystem` and make it compatible with `IPaymentProcessor`.
- Mapped incompatible legacy inputs in `PaymentAdapter.ProcessPayment`:
  - `Cvv` string -> `int`
  - `decimal` amount -> `double`
  - `ExpirationDate` -> month/year parameters
- Converted legacy response (`LegacyTransactionResponse`) into the modern result model (`PaymentResult`), including success flag, transaction id, and message.
- Adapted refund and status operations:
  - `RefundPayment` delegates to `ReverseTransaction`
  - `CheckStatus` converts legacy status string to `PaymentStatus`
- Wired the application in `Challenge.cs` by injecting `PaymentAdapter` into `CheckoutService`, allowing modern and legacy processors to coexist transparently.
