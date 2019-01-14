import React from 'react';
import jsonServerProvider from 'ra-data-json-server';
import { fetchUtils, Admin, Resource } from 'react-admin';
import { ProductList ,ProductEdit,ProductCreate } from './products';
import { UsersList, UserEdit, UserCreate } from './users';
import { CompanyList, CompanyEdit, CompanyCreate } from './company';
import { TransactionList, TransactionEdit, TransactionCreate } from './transaction';
import { UserAccessList, UserAccessCreate, UserAccessEdit} from './userpermission';
import { BalanceList} from './balance';
import UserIcon from '@material-ui/icons/Group';
import AccessRight from '@material-ui/icons/Settings';
import Store from '@material-ui/icons/Store';
import Business from '@material-ui/icons/Business';
import AccountBalanceWallet from '@material-ui/icons/AccountBalance';
import ShoppingBasket from '@material-ui/icons/ShoppingBasket';
import Dashboard from './Dashboard';
import authProvider from './authProvider';
import englishMessages from 'ra-language-english';
import swedishMessages from 'aor-language-swedish';


const messages = {
 
  'sv': swedishMessages,
};
const i18nProvider = locale => messages[locale];
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
  <Admin dashboard={Dashboard} dataProvider={dataProvider} authProvider={authProvider} locale="sv" messages={messages}>
      <Resource name="product" list={ProductList} edit={ProductEdit} create ={ProductCreate}  icon={Store}/>       
      <Resource name="transaction" list={TransactionList}  edit={TransactionEdit} create={TransactionCreate}  icon={ShoppingBasket}  />        
      <Resource name="balance" list={BalanceList}  icon={AccountBalanceWallet} />  
      <Resource name="users" list={UsersList}  edit={UserEdit} create={UserCreate}   icon={UserIcon}/> 
      <Resource name="company" list={CompanyList}  edit={CompanyEdit} create={CompanyCreate}  icon={Business}  /> 
      <Resource name="UserAccess" list={UserAccessList} create={UserAccessCreate} edit={UserAccessEdit} icon={AccessRight}  />  
  </Admin>
);

export default App;
