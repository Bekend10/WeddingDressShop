﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Home.aspx.cs" Inherits="E_WeddingDressShop.Views.Admin.Home" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Admin Dashboard</title>
    <style>
        body {
            font-family: Arial, sans-serif;
            background-color: #f8f8f8;
            color: #333333;
            margin: 0;
            padding: 0;
            display: flex;
            flex-direction: column;
            align-items: center;
            justify-content: center;
        }

        .dashboard {
            display: grid;
            grid-template-columns: repeat(4, 1fr);
            gap: 20px;
            padding: 20px;
            max-width: 1100px;
            width: 100%;
        }

        .card {
            background-color: #ffffff;
            border-radius: 10px;
            padding: 20px;
            box-shadow: 0 2px 5px rgba(0, 0, 0, 0.1);
        }

            .card h3 {
                margin: 0;
                font-size: 16px;
                color: #666666;
            }

            .card .value, .csstk {
                font-size: 28px;
                font-weight: bold;
                margin: 10px 0;
                color: #0066ff;
            }

        .chart {
            height: 120px;
            background: linear-gradient(90deg, #0066ff, #cccccc);
            border-radius: 8px;
        }

        .bar-chart {
            display: flex;
            justify-content: space-around;
            align-items: flex-end;
            height: 150px;
            background-color: #f0f0f0;
            border-radius: 8px;
            padding: 10px;
            position: relative;
        }

        .bar-container {
            display: flex;
            flex-direction: column;
            align-items: center;
            justify-content: flex-end;
        }

        .bar {
            width: 20px;
            background-color: #0066ff;
            border-radius: 4px;
            flex-grow: 1; /* Đảm bảo cột chiếm phần không gian còn lại */
        }

        .month-label {
            margin-top: 5px;
            font-size: 12px;
            color: #666666;
        }

        .pie-chart {
            width: 120px;
            height: 120px;
            border-radius: 50%;
            background: conic-gradient(#cccccc 0, #cccccc 100%);
            margin: 0 auto;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <div>
                <!-- Card 4: Cancellations -->
                <div class="card" style="margin-top:10px">
                    <h3>Tỉ lệ thành công hàng tháng</h3>
                    <asp:Label ID="lblCancellations" runat="server" CssClass="value"></asp:Label>
                    <div class="bar-chart" id="barChart">
                        <!-- Bars and months will be dynamically populated -->
                    </div>
                </div>

            </div>
            <div class="dashboard">
                <!-- Card 1 -->
                <div class="card">
                    <h3>Tổng doanh thu:</h3>
                    <asp:Label ID="lblTotalRevenue" runat="server" Text="0" CssClass="csstk"></asp:Label>

                </div>

                <!-- Card 2 -->
                <div class="card">
                    <h3>Tỷ lệ đơn hàng hủy</h3>
                    <asp:Label ID="lblCancellationRate" runat="server" Text="0" CssClass="csstk"></asp:Label>

                </div>

                <!-- Card 3: Order Status -->
                <div class="card">
                    <h3>Order Status</h3>
                    <div class="pie-chart" id="pieChart"></div>
                    <ul id="pieLegend">
                        <!-- Legend items will be dynamically populated -->
                    </ul>
                </div>


                <!-- Additional Cards -->

            </div>
        </div>
        <script>
            var t1 =<%= TinhToanTiLeCompletedPerMonth(1)%>;
            var t2 =<%= TinhToanTiLeCompletedPerMonth(2)%>;
            var t3 =<%= TinhToanTiLeCompletedPerMonth(3)%>;
            var t4 =<%= TinhToanTiLeCompletedPerMonth(4)%>;
            var t5 =<%= TinhToanTiLeCompletedPerMonth(5)%>;
            var t6 =<%= TinhToanTiLeCompletedPerMonth(6)%>;
            var t7 =<%= TinhToanTiLeCompletedPerMonth(7)%>;
            var t8 =<%= TinhToanTiLeCompletedPerMonth(8)%>;
            var t9 =<%= TinhToanTiLeCompletedPerMonth(9)%>;
            var t10 =<%= TinhToanTiLeCompletedPerMonth(10)%>;
            var t11 =<%= TinhToanTiLeCompletedPerMonth(11)%>;
            var t12 =<%= TinhToanTiLeCompletedPerMonth(12)%>;
            const barData = [
                { height: t1, month: "T1" },
                { height: t2, month: "T2" },
                { height: t3, month: "T3" },
                { height: t4, month: "T4" },
                { height: t5, month: "T5" },
                { height: t6, month: "T6" },
                { height: t7, month: "T7" },
                { height: t8, month: "T8" },
                { height: t9, month: "T9" },
                { height: t10, month: "T10" },
                { height: t11, month: "T11" },
                { height: t12, month: "T12" },
            ];
            const barChartContainer = document.getElementById('barChart');

            // Render Bars
            barData.forEach(data => {
                const barContainer = document.createElement('div');
                barContainer.classList.add('bar-container');

                const bar = document.createElement('div');
                bar.classList.add('bar');
                barContainer.style.height = `${data.height}%`;

                const label = document.createElement('div');
                label.classList.add('month-label');
                label.textContent = data.month;

                barContainer.appendChild(label);
                barContainer.appendChild(bar);
                barChartContainer.appendChild(barContainer);
            });

            // Biểu đồ tròn (40+30+30=100%)
            var completed =<%= getcompletedrateformbd()%>;
            var cancelled =<%= getcanceledrateformbd()%>;
            var other = 100 - completed.toFixed(2) - cancelled.toFixed(2);
            const pieData = [
                { label: "Completed", value: completed.toFixed(2), color: "#0066ff" },
                { label: "Canceled", value: cancelled.toFixed(2), color: "#ff9900" },
                { label: "Other", value: other.toFixed(2), color: "#828385" }
            ];

            const pieChartContainer = document.getElementById('pieChart');
            const pieLegendContainer = document.getElementById('pieLegend');

            // Render Pie Chart
            let currentAngle = 0;
            const pieSegments = pieData.map(data => {
                const angle = (data.value / 100) * 360;
                const startAngle = currentAngle;
                currentAngle += angle;
                return `${data.color} ${startAngle}deg ${currentAngle}deg`;
            }).join(', ');

            pieChartContainer.style.background = `conic-gradient(${pieSegments})`;

            // Render Pie Chart Legend
            pieData.forEach(data => {
                const legendItem = document.createElement('li');
                legendItem.textContent = `${data.label}: ${data.value}%`;
                legendItem.style.color = data.color;
                pieLegendContainer.appendChild(legendItem);
            });
        </script>
    </form>
</body>
</html>
