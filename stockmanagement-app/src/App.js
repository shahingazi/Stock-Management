import React from 'react';
import jsonServerProvider from 'ra-data-json-server';
import { fetchUtils, Admin, Resource } from 'react-admin';
import { ProductList ,ProductEdit,ProductCreate } from './products';
import { UsersList, UserEdit, UserCreate } from './users';
import { CompanyList, CompanyEdit, CompanyCreate } from './company';
import { TransactionList, TransactionEdit, TransactionCreate } from './transaction';
import { BalanceList} from './balance';
import UserIcon from '@material-ui/icons/Group';
import Store from '@material-ui/icons/Store';
import Business from '@material-ui/icons/Business';
import AccountBalanceWallet from '@material-ui/icons/AccountBalance';
import ShoppingBasket from '@material-ui/icons/ShoppingBasket';
import Dashboard from './Dashboard';
import authProvider from './authProvider';


const httpClient = (url, options = {}) => {
  if (!options.headers) {
      options.headers = new Headers({ Accept: 'application/json' });
  }
  const token = localStorage.getItem('token');
  options.headers.set('Authorization', `Bearer ${token}`);
  return fetchUtils.fetchJson(url, options);
}

const dataProvider = jsonServerProvider('http://localhost:8050/api/', httpClient);
const App = () => (
  <Admin dashboard={Dashboard} dataProvider={dataProvider} authProvider={authProvider}>
      <Resource name="product" list={ProductList} edit={ProductEdit} create ={ProductCreate}  icon={Store}/> 
      <Resource name="users" list={UsersList}  edit={UserEdit} create={UserCreate}   icon={UserIcon}/> 
      <Resource name="company" list={CompanyList}  edit={CompanyEdit} create={CompanyCreate}  icon={Business}  /> 
      <Resource name="transaction" list={TransactionList}  edit={TransactionEdit} create={TransactionCreate}  icon={ShoppingBasket}  />        
      <Resource name="balance" list={BalanceList}  icon={AccountBalanceWallet} />  
  </Admin>
);

export default App;
