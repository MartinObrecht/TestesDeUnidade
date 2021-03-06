using Flunt.Notifications;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestesDeUnidade.Domain.Command;
using TestesDeUnidade.Domain.Command.Interfaces;
using TestesDeUnidade.Domain.Entities;
using TestesDeUnidade.Domain.Handlers.Interfaces;
using TestesDeUnidade.Domain.Repositories;
using TestesDeUnidade.Domain.Utils;

namespace TestesDeUnidade.Domain.Handlers
{
    public class OrderHandler : Notifiable, IHandler<CreateOrderCommand>
    {
        private readonly ICustomerRepository _customerRepository;
        private readonly IDeliveryFeeRepository _deliveryFeeRepository;
        private readonly IDiscountRepository _discountRepository;
        private readonly IProductRepository _productRepository;
        private readonly IOrderRepository _orderRepository;

        public OrderHandler(
            ICustomerRepository customerRepository, 
            IDeliveryFeeRepository deliveryFeeRepository, 
            IDiscountRepository discountRepository, 
            IProductRepository productRepository, 
            IOrderRepository orderRepository)
        {
            _customerRepository = customerRepository;
            _deliveryFeeRepository = deliveryFeeRepository;
            _discountRepository = discountRepository;
            _productRepository = productRepository;
            _orderRepository = orderRepository;
        }

        public ICommandResult Handle(CreateOrderCommand command)
        {
            //Fail Fast Validation
            command.Validate();
            if (command.Invalid)
                return new GenericCommandResult(false,"Pedido inválido", command.Notifications);

            //1. Recupera o cliente
            var customer = _customerRepository.Get(command.Customer);

            //2. Calcular a taxa de entrega
            var deliveryFee = _deliveryFeeRepository.Get(command.ZipCode);

            //3. obtém o cupom de desconto
            var discount = _discountRepository.Get(command.PromoCode);

            //4. Gera o pedido
            var products = _productRepository.Get(ExtractGuids.Extract(command.Items)).ToList();
            var order = new Order(customer, deliveryFee, discount);
            foreach (var item in command.Items)
            {
                var product = products.Where(x => x.Id == item.Product).FirstOrDefault();
                order.AddItem(product, item.Quantity);
            }

            //5. Agrupa as notificações
            AddNotifications(order.Notifications);

            //6. Verifica se deu tudo certo
            if (Valid)
                return new GenericCommandResult(false, "Falha ao gerar pedido", Notifications);

            //7. Retorna o resultado
            _orderRepository.Save(order);
            return new GenericCommandResult(true, $"Pedido {order.Number} gerado com sucesso", order);

        }
    }
}
