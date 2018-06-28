!function(e){"use strict";var t=function(){this.VERSION="2.8.0",this.AUTHOR="Revox",this.SUPPORT="support@revox.io",this.$body=e("body"),this.color_green="#27cebc",this.color_blue="#00acec",this.color_yellow="#FDD01C",this.color_red="#f35958",this.color_grey="#dce0e8",this.color_black="#1b1e24",this.color_purple="#6d5eac",this.color_primary="#6d5eac",this.color_success="#4eb2f5",this.color_danger="#f35958",this.color_warning="#f7cf5e",this.color_info="#3b4751"};t.prototype.initHorizontalMenu=function(){e(".horizontal-menu .bar-inner > ul > li").on("click",function(){e(this).toggleClass("open").siblings().removeClass("open")}),e("body").hasClass("horizontal-menu")&&e(".content").on("click",function(){e(".horizontal-menu .bar-inner > ul > li").removeClass("open")})},t.prototype.initTooltipPlugin=function(){e.fn.tooltip&&e('[data-toggle="tooltip"]').tooltip()},t.prototype.initPopoverPlugin=function(){e.fn.popover&&e('[data-toggle="popover"]').popover()},t.prototype.initUnveilPlugin=function(){e.fn.unveil&&e("img").unveil()},t.prototype.initScrollUp=function(){e('[data-webarch="scrollup"]').click(function(){return e("html, body").animate({scrollTop:0},700),!1}),e(window).scroll(function(){e(this).scrollTop()>100?e('[data-webarch="scrollup"]').fadeIn():e('[data-webarch="scrollup"]').fadeOut()})},t.prototype.initPortletTools=function(){var t=this;e(".grid .tools a.remove").on("click",function(){var e=jQuery(this).parents(".grid");e.next().hasClass("grid")||e.prev().hasClass("grid")?jQuery(this).parents(".grid").remove():jQuery(this).parents(".grid").parent().remove()}),e(".grid .tools a.reload").on("click",function(){var e=jQuery(this).parents(".grid");t.blockUI(e),window.setTimeout(function(){t.unblockUI(e)},1e3)}),e(".grid .tools .collapse, .grid .tools .expand").on("click",function(){var e=jQuery(this).parents(".grid").children(".grid-body");jQuery(this).hasClass("collapse")?(jQuery(this).removeClass("collapse").addClass("expand"),e.slideUp(200)):(jQuery(this).removeClass("expand").addClass("collapse"),e.slideDown(200))}),e(".widget-item > .controller .reload").click(function(){var i=e(this).parent().parent();t.blockUI(i),window.setTimeout(function(){t.unblockUI(i)},1e3)}),e(".widget-item > .controller .remove").click(function(){e(this).parent().parent().parent().addClass("animated fadeOut"),e(this).parent().parent().parent().attr("id","id_remove_temp_id"),setTimeout(function(){e("#id_remove_temp_id").remove()},400)}),e(".tiles .controller .reload").click(function(){var i=e(this).parent().parent().parent();t.blockUI(i),window.setTimeout(function(){t.unblockUI(i)},1e3)}),e(".tiles .controller .remove").click(function(){e(this).parent().parent().parent().parent().addClass("animated fadeOut"),e(this).parent().parent().parent().parent().attr("id","id_remove_temp_id"),setTimeout(function(){e("#id_remove_temp_id").remove()},400)}),jQuery().sortable&&e(".sortable").sortable({connectWith:".sortable",iframeFix:!1,items:"div.grid",opacity:.8,helper:"original",revert:!0,forceHelperSize:!0,placeholder:"sortable-box-placeholder round-all",forcePlaceholderSize:!0,tolerance:"pointer"})},t.prototype.initScrollBar=function(){e.fn.scrollbar&&e(".scroller").each(function(){var t=e(this).attr("data-height");e(this).scrollbar({ignoreMobile:!0}),(null!=t||""!=t)&&(e(this).parent(".scroll-wrapper").length>0?e(this).parent().css("max-height",t):e(this).css("max-height",t))})},t.prototype.initSideBar=function(){var t=e(".page-sidebar"),i=e(".page-sidebar .page-sidebar-wrapper");if(t.find("li > a").on("click",function(t){if(e(this).next().hasClass("sub-menu")!==!1){var i=e(this).parent().parent();i.children("li.open").children("a").children(".arrow").removeClass("open"),i.children("li.open").children("a").children(".arrow").removeClass("active"),i.children("li.open").children(".sub-menu").slideUp(200),i.children("li").removeClass("open");var n=jQuery(this).next();n.is(":visible")?(jQuery(".arrow",jQuery(this)).removeClass("open"),jQuery(this).parent().removeClass("active"),n.slideUp(200,function(){})):(jQuery(".arrow",jQuery(this)).addClass("open"),jQuery(this).parent().addClass("open"),n.slideDown(200,function(){})),t.preventDefault()}}),t.hasClass("mini")){var n=jQuery(".page-sidebar ul");n.children("li.open").children("a").children(".arrow").removeClass("open"),n.children("li.open").children("a").children(".arrow").removeClass("active"),n.children("li.open").children(".sub-menu").slideUp(200),n.children("li").removeClass("open")}e.fn.scrollbar&&i.scrollbar()},t.prototype.toggleLeftSideBar=function(){var t;e("body").hasClass("open-menu-left")?(e("body").removeClass("open-menu-left"),t=setTimeout(function(){e(".page-sidebar").removeClass("visible")},300)):(clearTimeout(t),e(".page-sidebar").addClass("visible"),setTimeout(function(){e("body").addClass("open-menu-left")},50))},t.prototype.toggleRightSideBar=function(){var t;e("body").hasClass("open-menu-right")?(e("body").removeClass("open-menu-right"),t=setTimeout(function(){e(".chat-window-wrapper").removeClass("visible")},300)):(clearTimeout(t),e(".chat-window-wrapper").addClass("visible"),e("body").addClass("open-menu-right"))},t.prototype.initUtil=function(){function t(t){var i=0;t.each(function(){var t=e(this).height();t>i&&(i=t)}),t.height(i)}e('[data-height-adjust="true"]').each(function(){var t=e(this).attr("data-elem-height");e(this).css("min-height",t),e(this).css("background-image","url("+e(this).attr("data-background-image")+")"),e(this).css("background-repeat","no-repeat"),e(this).attr("data-background-image")}),e('[data-aspect-ratio="true"]').each(function(){e(this).height(e(this).width())}),e('[data-sync-height="true"]').each(function(){t(e(this).children())}),e('[data-webarch-toggler="checkall"]').on("click",function(){var t=e(this),i=t.closest("table");t.is(":checked")?(i.find(":checkbox").attr("checked",!0),i.find("tr").addClass("row_selected")):(i.find(":checkbox").attr("checked",!1),i.find("tr").removeClass("row_selected"))}),e(window).resize(function(){e('[data-aspect-ratio="true"]').each(function(){e(this).height(e(this).width())}),e('[data-sync-height="true"]').each(function(){t(e(this).children())})}),e("#my-task-list").popover({html:!0,content:function(){return e("#notification-list").html()}}),e("#user-options").click(function(){e("#my-task-list").popover("hide")}),e("table th .checkall").on("click",function(){e(this).is(":checked")?(e(this).closest("table").find(":checkbox").attr("checked",!0),e(this).closest("table").find("tr").addClass("row_selected")):(e(this).closest("table").find(":checkbox").attr("checked",!1),e(this).closest("table").find("tr").removeClass("row_selected"))})},t.prototype.initProgress=function(){e('[data-init="animate-number"], .animate-number').each(function(){var t=e(this).data();e(this).animateNumbers(t.value,!0,parseInt(t.animationDuration,10))}),e('[data-init="animate-progress-bar"], .animate-progress-bar').each(function(){var t=e(this).data();e(this).css("width",t.percentage)})},t.prototype.initSelect2Plugin=function(){e.fn.select2&&e('[data-init-plugin="select2"]').each(function(){e(this).select2({minimumResultsForSearch:"true"==e(this).attr("data-disable-search")?-1:1}).on("select2-opening",function(){e.fn.scrollbar&&e(".select2-results").scrollbar({ignoreMobile:!1})})})},t.prototype.initFormElements=function(){e(".inside").children("input").blur(function(){e(this).parent().children(".add-on").removeClass("input-focus")}),e(".inside").children("input").focus(function(){e(this).parent().children(".add-on").addClass("input-focus")}),e(".input-group.transparent").children("input").blur(function(){e(this).parent().children(".input-group-addon").removeClass("input-focus")}),e(".input-group.transparent").children("input").focus(function(){e(this).parent().children(".input-group-addon").addClass("input-focus")}),e(".bootstrap-tagsinput input").blur(function(){e(this).parent().removeClass("input-focus")}),e(".bootstrap-tagsinput input").focus(function(){e(this).parent().addClass("input-focus")})},t.prototype.initValidatorPlugin=function(){e.validator&&e.validator.setDefaults({errorPlacement:function(t,i){var n=e(i).closest(".form-group");n.hasClass("form-group-default")?(n.addClass("has-error"),t.insertAfter(n)):t.insertAfter(i)},onfocusout:function(t){var i=e(t).closest(".form-group");e(t).valid()&&(i.removeClass("has-error"),i.next(".error").remove())},onkeyup:function(t){var i=e(t).closest(".form-group");e(t).valid()?(e(t).removeClass("error"),i.removeClass("has-error"),i.next("label.error").remove(),i.find("label.error").remove()):i.addClass("has-error")},success:function(){}}),e(".validate").validate()},t.prototype.blockUI=function(t){e(t).block({message:'<div class="loading-animator"></div>',css:{border:"none",padding:"2px",backgroundColor:"none"},overlayCSS:{backgroundColor:"#fff",opacity:.3,cursor:"wait"}})},t.prototype.unblockUI=function(t){e(t).unblock()},t.prototype.navMenu=function(){this.menuClose=0,e("#headerNav").css("max-height",e(window).height()-50+"px"),e("#headerMenu").on("click",function(){this.menuClose?(this.menuClose=0,e("#headerNav").slideUp(),e("body").css("overflow","auto")):(this.menuClose=1,e("#headerNav").slideDown(),e("body").css("overflow","hidden"))})},t.prototype.init=function(){this.initSideBar(),this.navMenu(),this.initHorizontalMenu(),this.initPortletTools(),this.initScrollUp(),this.initProgress(),this.initFormElements(),this.initSelect2Plugin(),this.initUnveilPlugin(),this.initScrollBar(),this.initTooltipPlugin(),this.initPopoverPlugin(),this.initValidatorPlugin(),this.initUtil(),this.url=window.location;var t=this;this.element=e("#headerNav a").filter(function(){return this.href==t.url||0==t.url.href.indexOf(this.href)}),this.element.parents("ul.sub-menu").length?this.element.parents("ul.sub-menu").parent("li").addClass("active"):this.element.parent("li").addClass("active")},e.Webarch=new t,e.Webarch.Constructor=t}(window.jQuery),$(document).ready(function(){$("#menu-collapse").click(function(){$(".page-sidebar").hasClass("mini")?($(".page-sidebar").removeClass("mini"),$(".page-content").removeClass("condensed-layout"),$(".footer-widget").show()):($(".page-sidebar").addClass("mini"),$(".page-content").addClass("condensed-layout"),$(".footer-widget").hide())}),$(".simple-chat-popup").click(function(){$(this).addClass("hide"),$("#chat-message-count").addClass("hide")}),setTimeout(function(){$("#chat-message-count").removeClass("hide"),$("#chat-message-count").addClass("animated bounceIn"),$(".simple-chat-popup").removeClass("hide"),$(".simple-chat-popup").addClass("animated fadeIn")},5e3),setTimeout(function(){$(".simple-chat-popup").addClass("hide"),$(".simple-chat-popup").removeClass("animated fadeIn"),$(".simple-chat-popup").addClass("animated fadeOut")},8e3),$("#layout-condensed-toggle").click(function(){"1"==$("#main-menu").attr("data-inner-menu")||($("#main-menu").hasClass("mini")?($("body").removeClass("grey"),$("body").removeClass("condense-menu"),$("#main-menu").removeClass("mini"),$(".page-content").removeClass("condensed"),$(".scrollup").removeClass("to-edge"),$(".header-seperation").show(),$(".header-seperation").css("height","61px"),$(".footer-widget").show()):($("body").addClass("grey"),$("#main-menu").addClass("mini"),$(".page-content").addClass("condensed"),$(".scrollup").addClass("to-edge"),$(".header-seperation").hide(),$(".footer-widget").hide(),$(".main-menu-wrapper").scrollbar("destroy")))}),$.fn.sparkline&&$(".sparklines").sparkline("html",{enableTagOptions:!0})}),function(e){e.fn.toggleMenu=function(){var t=window.innerWidth;t>768&&e(this).toggleClass("hide-sidebar")},e.fn.condensMenu=function(){var t=window.innerWidth;t>768&&(e(this).hasClass("hide-sidebar")&&e(this).toggleClass("hide-sidebar"),e(this).toggleClass("condense-menu"),e(this).find("#main-menu").toggleClass("mini"))},e.fn.toggleFixedMenu=function(){var t=window.innerWidth;t>768&&e(this).toggleClass("menu-non-fixed")},e.fn.toggleHeader=function(){e(this).toggleClass("hide-top-content-header")},e.fn.toggleChat=function(){e.Webarch.toggleRightSideBar()},e.fn.layoutReset=function(){e(this).removeClass("hide-sidebar"),e(this).removeClass("condense-menu"),e(this).removeClass("hide-top-content-header"),e("body").hasClass("extended-layout")||e(this).find("#main-menu").removeClass("mini")}}(jQuery),$(function(){"use strict";$.Webarch.init()});