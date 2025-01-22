import React from 'react';
import { 
  Clock, 
  Plane, 
  Receipt, 
  ShoppingCart, 
  RefreshCw,
  PlusCircle,
  FileText,
  Phone,
  Home,
  CreditCard,
  Settings,
  BarChart3
} from 'lucide-react';
import MiniDrawer from './Sidebar';
import Box from '@mui/material/Box';

const DashboardCard = ({ children, className = '' }) => (
  <div className={`bg-gray-900 rounded-lg p-4 ${className}`}>
    {children}
  </div>
);

const TaskItem = ({ icon: Icon, text, value, valueIsEuro }) => (
  <div className="flex items-center justify-between py-2">
    <div className="flex items-center gap-3">
      <Icon className="w-5 h-5 text-gray-400" />
      <span className="text-gray-400">{text}</span>
    </div>
    <span className="text-white">
      {valueIsEuro ? '€' : ''}{value}
    </span>
  </div>
);

const ExpenseRow = ({ subject, employee, team, amount }) => (
  <div className="flex items-center justify-between py-2">
    <div className="w-1/4">
      <span className="text-gray-400">{subject}</span>
    </div>
    <div className="w-1/4">
      <span className="text-gray-400">{employee}</span>
    </div>
    <div className="w-1/4">
      <span className={`px-2 py-1 rounded-full text-xs ${
        team === 'Marketing' ? 'bg-indigo-900 text-indigo-200' :
        team === 'Sales' ? 'bg-red-900 text-red-200' :
        team === 'Operations' ? 'bg-pink-900 text-pink-200' :
        'bg-teal-900 text-teal-200'
      }`}>
        {team}
      </span>
    </div>
    <div className="w-1/4 text-right">
      <span className="text-white">€{amount}</span>
    </div>
  </div>
);

const QuickAccessButton = ({ icon: Icon, text, color }) => (
  <button className="flex items-center gap-2 p-4 rounded-lg bg-gray-800 hover:bg-gray-700 transition-colors w-full">
    <div className={`p-2 rounded-lg ${color}`}>
      <Icon className="w-5 h-5 text-white" />
    </div>
    <span className="text-white text-sm">{text}</span>
  </button>
);

const BarChart = ({ data, title }) => (
  <div className="flex-1">
    <h3 className="text-gray-400 mb-4">{title}</h3>
    <div className="flex items-end h-40 gap-2">
      {data.map((item, index) => (
        <div key={index} className="flex-1 flex flex-col items-center gap-2">
          <div 
            className="w-full bg-teal-500 rounded-t"
            style={{ height: `${item.value}%` }}
          ></div>
          <span className="text-gray-400 text-xs">{item.label}</span>
        </div>
      ))}
    </div>
  </div>
);

export default function Dashboard() {
  const pendingTasks = [
    { icon: Clock, text: "Pending Approvals", value: 5 },
    { icon: Plane, text: "New Trips Registered", value: 1 },
    { icon: Receipt, text: "Unreported Expenses", value: 4 },
    { icon: ShoppingCart, text: "Upcoming Expenses", value: 0 },
    { icon: RefreshCw, text: "Unreported Advances", value: "0.00", valueIsEuro: true }
  ];

  const recentExpenses = [
    { subject: "Office Supplies", employee: "John Smith", team: "Marketing", amount: "150.00" },
    { subject: "Business Lunch", employee: "Sarah Jade", team: "Sales", amount: "75.50" },
    { subject: "Travel Expenses", employee: "Mike Brown", team: "Operations", amount: "450.25" },
    { subject: "Client Dinner", employee: "Jennifer Lee", team: "Marketing", amount: "120.00" },
    { subject: "Hotel", employee: "David Wilson", team: "Finance", amount: "275.75" }
  ];

  const quickActions = [
    { icon: PlusCircle, text: "+ New expense", color: "bg-pink-600" },
    { icon: Receipt, text: "+ Add receipt", color: "bg-indigo-600" },
    { icon: FileText, text: "+ Create report", color: "bg-teal-600" },
    { icon: Plane, text: "+ Create trip", color: "bg-red-600" }
  ];

  const teamSpendingData = [
    { label: 'FG', value: 60 },
    { label: 'SJ', value: 30 },
    { label: 'MB', value: 70 },
    { label: 'IS', value: 65 },
    { label: 'DM', value: 35 },
    { label: 'NG', value: 45 },
    { label: 'BS', value: 80 }
  ];

  const dayExpensesData = [
    { label: 'Accom', value: 40 },
    { label: 'Comms', value: 20 },
    { label: 'Services', value: 90 },
    { label: 'Food', value: 70 },
    { label: 'Fuel', value: 30 }
  ];

  return (
    <Box>
      <MiniDrawer />
      <Box 
        component="main" 
        sx={{ 
          flexGrow: 1, 
          bgcolor: 'black',
          minHeight: '92.9vh',
          marginLeft: '60px'
        }}
      >
        <div className="p-6 pt-10">
          <div className="flex flex-col gap-6">
            {/* Top Cards */}
            <div className="grid grid-cols-2 gap-6">
              <DashboardCard>
                <h2 className="text-lg font-semibold mb-4">Pending Tasks</h2>
                {pendingTasks.map((task, index) => (
                  <TaskItem key={index} {...task} />
                ))}
              </DashboardCard>

              <DashboardCard>
                <h2 className="text-lg font-semibold mb-4">Recent Expenses</h2>
                {recentExpenses.map((expense, index) => (
                  <ExpenseRow key={index} {...expense} />
                ))}
              </DashboardCard>
            </div>

            {/* Quick Access */}
            <DashboardCard>
              <h2 className="text-lg font-semibold mb-4">Quick Access</h2>
              <div className="grid grid-cols-4 gap-4">
                {quickActions.map((action, index) => (
                  <QuickAccessButton key={index} {...action} />
                ))}
              </div>
            </DashboardCard>

            {/* Monthly Report */}
            <DashboardCard>
              <h2 className="text-lg font-semibold mb-6">Monthly Report</h2>
              <div className="flex gap-6">
                <BarChart 
                  title="Team Spending Trend" 
                  data={teamSpendingData} 
                />
                <BarChart 
                  title="Day-to-Day Expenses" 
                  data={dayExpensesData} 
                />
              </div>
            </DashboardCard>
          </div>
        </div>
      </Box>
    </Box>
  );
}

