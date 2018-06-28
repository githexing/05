var FlotChart=function(){this.$body=$("body"),this.$realData=[]};FlotChart.prototype.createPlotGraph=function(o,t,l,a,e,r,i){$.plot($(o),[{data:t,label:a[0],color:e[0]},{data:l,label:a[1],color:e[1]}],{series:{lines:{show:!0,fill:!0,lineWidth:2,fillColor:{colors:[{opacity:.4},{opacity:.4}]}},points:{show:!1},shadowSize:0},grid:{hoverable:!0,clickable:!0,borderColor:r,tickColor:"#f9f9f9",borderWidth:1,labelMargin:10,backgroundColor:i},legend:{position:"ne",margin:[0,-24],noColumns:0,labelBoxBorderColor:null,labelFormatter:function(o){return""+o+"&nbsp;&nbsp;"},width:30,height:2},yaxis:{tickColor:"#f5f5f5",font:{color:"#bdbdbd"}},xaxis:{tickColor:"#f5f5f5",font:{color:"#bdbdbd"}},tooltip:!0,tooltipOpts:{content:"%s: Value of %x is %y",shifts:{x:-60,y:25},defaultTheme:!1}})},FlotChart.prototype.createPieGraph=function(o,t,l,a){var e=[{label:t[0],data:l[0]},{label:t[1],data:l[1]},{label:t[2],data:l[2]}],r={series:{pie:{show:!0}},legend:{show:!0},grid:{hoverable:!0,clickable:!0},colors:a,tooltip:!0,tooltipOpts:{content:"%s, %p.0%"}};$.plot($(o),e,r)},FlotChart.prototype.randomData=function(){var o=300;for(this.$realData.length>0&&(this.$realData=this.$realData.slice(1));this.$realData.length<o;){var t=this.$realData.length>0?this.$realData[this.$realData.length-1]:50,l=t+10*Math.random()-5;0>l?l=0:l>100&&(l=100),this.$realData.push(l)}for(var a=[],e=0;e<this.$realData.length;++e)a.push([e,this.$realData[e]]);return a},FlotChart.prototype.createRealTimeGraph=function(o,t,l){var a=$.plot(o,[t],{colors:l,series:{grow:{active:!1},shadowSize:0,lines:{show:!0,fill:!1,lineWidth:2,steps:!1}},grid:{show:!0,aboveData:!1,color:"#dcdcdc",labelMargin:15,axisMargin:0,borderWidth:0,borderColor:null,minBorderMargin:5,clickable:!0,hoverable:!0,autoHighlight:!1,mouseActiveRadius:20},tooltip:!0,tooltipOpts:{content:"Value is : %y.0%",shifts:{x:-30,y:-50}},yaxis:{min:1,max:2,tickColor:"#f5f5f5",color:"rgba(0,0,0,0.1)"},xaxis:{show:!1,tickColor:"#f5f5f5"}});return a},FlotChart.prototype.createDonutGraph=function(o,t,l,a){var e=[{label:t[0],data:l[0]},{label:t[1],data:l[1]},{label:t[2],data:l[2]},{label:t[3],data:l[3]}],r={series:{pie:{show:!0,innerRadius:.7}},legend:{show:!0,labelFormatter:function(o){return'<div style="font-size:14px;">&nbsp;'+o+"</div>"},labelBoxBorderColor:null,margin:50,width:20,padding:1},grid:{hoverable:!0,clickable:!0},colors:a,tooltip:!0,tooltipOpts:{content:"%s, %p.0%"}};$.plot($(o),e,r)},FlotChart.prototype.createCombineGraph=function(o,t,l,a){var e=[{label:l[0],data:a[0],lines:{show:!0,fill:!0},points:{show:!0}},{label:l[1],data:a[1],lines:{show:!0},points:{show:!0}},{label:l[2],data:a[2],bars:{show:!0}}],r={series:{shadowSize:0},grid:{hoverable:!0,clickable:!0,tickColor:"#f9f9f9",borderWidth:1,borderColor:"#eeeeee"},colors:["#ff8acc","#5b69bc","#10c469"],tooltip:!0,tooltipOpts:{defaultTheme:!1},legend:{position:"ne",margin:[0,-24],noColumns:0,labelBoxBorderColor:null,labelFormatter:function(o){return""+o+"&nbsp;&nbsp;"},width:30,height:2},yaxis:{tickColor:"#f5f5f5",font:{color:"#bdbdbd"}},xaxis:{ticks:t,tickColor:"#f5f5f5",font:{color:"#bdbdbd"}}};$.plot($(o),e,r)};