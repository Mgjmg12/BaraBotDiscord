using DSharpPlus;
using DSharpPlus.CommandsNext;
using DSharpPlus.CommandsNext.Attributes;
using DSharpPlus.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;

namespace BaraBot.Commands
{
    public class BaraCommands : BaseCommandModule
    {
        [Command("bara")]
        public async Task BaraPhrase(CommandContext context)
        {
            String[] BaraFrases = new String []{ "PANTIIIII", "Pero yo..te amo","La de mandar cv se la saben?","Juega Dios","Paga Dios","Se la gastan en babasonicos",
            "Paga jm el helado","Pero para","Osea yo","Yo vote a M****","Es que estoy gaga","Esa cosa verde","Mañana se labura abz","DEJEN DE MANCHAR A VUOL","Ppppppero","Se acaba la joda",
            "Todos acá boludeando y uno acá LABURANDO"};
            Random rmd = new Random();
            var index = rmd.Next(0, BaraFrases.Length);

            var message = new DiscordEmbedBuilder
            {
                Title = "Tu bara frase es: ",
                Description = BaraFrases[index],
                Color=DiscordColor.Red,
            };
            await context.Channel.SendMessageAsync(embed: message);
        }

        [Command("limpiarBaraFrases")]
        public async Task Clear(CommandContext ctx, int cantidad)
        {
            if (!ctx.Member.PermissionsIn(ctx.Channel).HasPermission(Permissions.ManageMessages))
            {
                await ctx.RespondAsync("No tienes permiso para limpiar mensajes en este canal.");
                return;
            }

            var mensajes = await ctx.Channel.GetMessagesAsync(cantidad + 1);

            await ctx.Channel.DeleteMessagesAsync(mensajes);

            await ctx.RespondAsync($"Se han eliminado {cantidad} mensajes.");
        }
    }
}
