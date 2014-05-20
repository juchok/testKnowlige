testKnowlige
============
<membership defaultProvider="MembershipProviderEx">
        <providers>
          <clear />
          <add name="MembershipProviderEx"
               requiresQuestionAndAnswer="false"
               passwordFormat="Hashed"
               enablePasswordReset="true"
               enablePasswordRetrieval="false"
               minRequiredPasswordLength="5"
               minRequiredNonalphanumericCharacters="0"
               connectionStringName="Ctest2009"
               applicationName="/"
               type="System.Web.Security.SqlMembershipProvider, System.Web, Version=2.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a" />
        </providers>
      </membership>      
