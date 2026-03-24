// DESAFIO: Integração com Sistema Legado de Pagamentos
// PROBLEMA: Um e-commerce moderno precisa integrar com um sistema legado de processamento
// de pagamentos que usa interfaces e estruturas de dados incompatíveis com o sistema atual
// O código atual não consegue usar o sistema legado sem grandes mudanças na aplicação

using System;
using DesignPatternChallenge.Adapters;
using DesignPatternChallenge.Processors;
using DesignPatternChallenge.Responses;
using DesignPatternChallenge.Services;

namespace DesignPatternChallenge
{
    
    
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("=== Sistema de Checkout ===\n");

            // Funciona bem com o processador moderno
            var modernProcessor = new ModernPaymentProcessor();
            var checkoutWithModern = new CheckoutService(modernProcessor);
            checkoutWithModern.CompleteOrder("cliente@email.com", 150.00m, "4111111111111111");

            Console.WriteLine("\n" + new string('-', 60) + "\n");

            // Problema: Como usar o sistema legado sem modificar CheckoutService?
            var legacySystem = new LegacyPaymentSystem();
            
            var paymentAdapter = new PaymentAdapter(legacySystem);

            var checkoutWithLegacy = new CheckoutService(paymentAdapter);
            checkoutWithLegacy.CompleteOrder("cliente@email.com", 150.00m, "4111111111111111");
           
            // Perguntas para reflexão:
            // - Como fazer o sistema legado trabalhar com a interface moderna?
            // - Como evitar modificar CheckoutService e outras classes que usam IPaymentProcessor?
            // - Como encapsular as conversões entre as interfaces incompatíveis?
            // - Como permitir que ambos os sistemas coexistam de forma transparente?
        }
    }
}
